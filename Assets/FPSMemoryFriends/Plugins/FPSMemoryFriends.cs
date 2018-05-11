using UnityEngine;
using UnityEngine.Profiling;
using System;
#if UNITY_IPHONE
using System.Runtime.InteropServices;
#endif

namespace Friends
{
    [AddComponentMenu("Friends/FPSMemoryFriends")]
    public class FPSMemoryFriends : MonoBehaviour
    {
#if UNITY_IPHONE
        [DllImport("__Internal")] static extern int getUsedMemory();
#endif

        [SerializeField] bool autoUpdateMemory = true;
        [SerializeField] int fps;
        [SerializeField] long usedMemory;
        [SerializeField] long usedMemoryKB;
        [SerializeField] long usedMemoryMB;
        float startTime;
        int frame;

        public int FPS           { get { return fps;          } }
        public long UsedMemory   { get { return usedMemory;   } }
        public long UsedMemoryKB { get { return usedMemoryKB; } }
        public long UsedMemoryMB { get { return usedMemoryMB; } }

        void Update()
        {
            var elapsedTime = Time.realtimeSinceStartup - startTime;
            if(elapsedTime >= 1)
            {
                fps       = frame;
                frame     = 0;
                startTime = Time.realtimeSinceStartup;
                if(autoUpdateMemory) UpdateUsedMemory();
            }
            else
            {
                frame++;
            }
        }

        public void UpdateUsedMemory()
        {
#if UNITY_EDITOR
            usedMemory   = GC.GetTotalMemory(false) + Profiler.usedHeapSizeLong;
            usedMemoryKB = usedMemory   / 1024;
            usedMemoryMB = usedMemoryKB / 1024;
#elif UNITY_IPHONE
            usedMemory   = getUsedMemory();
            usedMemoryKB = usedMemory   / 1024;
            usedMemoryMB = usedMemoryKB / 1024;
#elif UNITY_ANDROID
            using(var plugin = new AndroidJavaClass("jp.okamura0510.fpsmemoryfriendsandroid.FPSMemoryFriends"))
            {
                usedMemoryKB = plugin.CallStatic<long>("getUsedMemoryKB");
                usedMemory   = usedMemoryKB * 1024;
                usedMemoryMB = usedMemoryKB / 1024;
            }
#endif
        }
    }
}