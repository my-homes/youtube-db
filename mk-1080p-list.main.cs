//+#nuget Global.Sys
using Global;
using System;
using System.Text;
using static Global.EasyObject;
using static Global.Sys;
try
{
    ShowDetail = true;
    //SilentFlag = true;
    SetCwd(HomeFolder("youtube-db"));
    var videoPathList = FromFile("all/1080p-full-path.json");
    Log(videoPathList);
    foreach(var videoPath in videoPathList.AsList!)
    {
        string line = videoPath.Cast<string>();
        Log(line);
        var m = Sys.FindFirstMatch(
            line,
            @"\[([^\[\]]+)\][.]mp4$",
            @"【ID：([^【】]+)】[.]mp4$"
        );
        Log(m);
    }
}
catch (Exception e)
{
    Crash(e);
}
