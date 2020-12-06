using System;
using System.IO;
using System.Threading.Tasks;
using FFMpegCore;
using FFMpegCore.Enums;
using FFMpegCore.Pipes;

const string FILE_NAME = "Data/Friends";
const string MP3_PATH = FILE_NAME + ".mp3";
// const string OPUS_PATH = FILE_NAME + ".opus";
// const string RAW_PATH = FILE_NAME + ".raw";


using var sourceStream = File.Open(MP3_PATH, FileMode.Open);

var mediaInfo1 = await FFProbe.AnalyseAsync(sourceStream);
var mediaInfo2 = await FFProbe.AnalyseAsync(MP3_PATH);

var duration1 = mediaInfo1.Duration;
var duration2 = mediaInfo2.Duration;