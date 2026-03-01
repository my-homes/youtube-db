//+#nuget Global.Sys
using Global;
using System;
using System.Text;
using static Global.EasyObject;
using static Global.Sys;
try
{
    //ShowDetail = true;
    //SilentFlag = true;
    SetCwd(HomeFolder("youtube-db"));
    var all = FromFile("all/all.json");
    var videoPathList = FromFile("all/1080p-full-path.json");
    Log(videoPathList);
    var result = NewObject();
    foreach(var videoPath in videoPathList.AsList!)
    {
        string fullPath = videoPath.Cast<string>();
        Log(fullPath);
        var m = Sys.FindFirstMatch(
            fullPath,
            @"\[([^\[\]]+)\][.]mp4$",
            @"【ID：([^【】]+)】[.]mp4$"
        );
        //Log(m);
        if ( m != null )
        {
            string id = m[1];
            Log(id, "id");
            var info = all[id];
            info = info.Clone(hideKeys: ["detail"]);
            string videoDuration = info["duration"].Cast<string>();
            TimeSpan duration = TimeSpan.Parse(videoDuration);
            var minutes = duration.TotalMinutes;
            info.Dynamic.minutes = minutes;
            info.Dynamic.path = fullPath;
            Log(info);
            result.Add(info);
        }
    }
    DumpObjectAsJson(result);
}
catch (Exception e)
{
    Crash(e);
}
