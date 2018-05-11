using UnityEngine;
using UnityEngine.UI;

namespace Friends
{
    public class Demo : MonoBehaviour
    {
        [SerializeField] FPSMemoryFriends fpsMemoryFriends;
        [SerializeField] Text text;

        void Update()
        {
            text.text = 
                "FPS："          + fpsMemoryFriends.FPS          + "\n" +
                "UsedMemory："   + fpsMemoryFriends.UsedMemory   + "\n" +
                "UsedMemoryKB：" + fpsMemoryFriends.UsedMemoryKB + "\n" +
                "UsedMemoryMB：" + fpsMemoryFriends.UsedMemoryMB;
        }
    }
}