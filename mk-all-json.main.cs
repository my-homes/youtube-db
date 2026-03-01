//+#nuget Global.Sys
using System;
using System.Text;
using static Global.EasyObject;
using static Global.Sys;
try
{
    ShowDetail = true;
    SilentFlag = true;
    //string path = HomeFolder("youtube-db");
    string path = ".";
    //Log(path);
    string output = GetProcessStdout(
        Encoding.UTF8,
        "dir-multi.exe",
        path
        );
    var lines = TextToLines(output);
    var videoDict = NewObject();
    Log(lines.Count);
    foreach (var line in lines)
    {
        Log(line);
        if (!line.EndsWith(".json")) continue;
        var eo = FromFile(line);
        videoDict.Add(eo["id"].Cast<string>(), eo.Clone(maxDepth: 1));
    }
    Log(videoDict.Count);
    DumpObjectAsJson(videoDict);
}
catch (Exception e)
{
    Crash(e);
}
