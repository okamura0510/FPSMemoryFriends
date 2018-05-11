package jp.okamura0510.fpsmemoryfriendsandroid;

import android.content.Context;
import android.app.ActivityManager;
import android.os.Debug;
import android.os.Process;

import com.unity3d.player.UnityPlayer;

public class FPSMemoryFriends
{
    public static long getUsedMemoryKB() {
        long usedMemoryKB               = 0;
        Context context                 = UnityPlayer.currentActivity.getApplication().getApplicationContext();
        ActivityManager activityManager = (ActivityManager)context.getSystemService(Context.ACTIVITY_SERVICE);
        Debug.MemoryInfo[] memoryInfos  = activityManager.getProcessMemoryInfo(new int[]{ Process.myPid() });
        for(Debug.MemoryInfo mi : memoryInfos) {
            usedMemoryKB += mi.getTotalPss();
        }
        return usedMemoryKB;
    }
}