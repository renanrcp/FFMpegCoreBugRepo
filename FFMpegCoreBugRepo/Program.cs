using System;
using System.IO;
using System.Threading.Tasks;
using FFMpegCore;
using FFMpegCore.Enums;
using FFMpegCore.Pipes;

const string FILE_NAME = "Marshmello & Anne-Marie - FRIENDS (Lyric Video) _OFFICIAL FRIENDZONE ANTHEM";
const string MP3_PATH = FILE_NAME + ".mp3";
const string OPUS_PATH = FILE_NAME + ".opus";
const string RAW_PATH = FILE_NAME + ".raw";


using var ms1 = await PipeBroken1Async();
//using var ms2 = await PipeBroken2Async();
//using var ms3 = await PipeBroken3Async();
//using var ms4 = await WorkingPipeAsync();

static async Task<Stream> PipeBroken1Async()
{
    using var file = File.Open(MP3_PATH, FileMode.Open);

    var memoryStream = new MemoryStream();

    // Try convert to opus
    await FFMpegArguments
            .FromPipeInput(new StreamPipeSource(file))
            .OutputToPipe(new StreamPipeSink(memoryStream), options =>
            {
                options.WithAudioSamplingRate(48000);
                options.WithAudioCodec("libopus");
                options.WithCustomArgument("-ac 2");
            })
            .ProcessAsynchronously();

    return memoryStream;
}

static async Task<Stream> PipeBroken2Async()
{
    using var file = File.Open(OPUS_PATH, FileMode.Open);

    var memoryStream = new MemoryStream();

    // Try convert to mp3
    await FFMpegArguments
            .FromPipeInput(new StreamPipeSource(file))
            .OutputToPipe(new StreamPipeSink(memoryStream), options =>
            {
                options.WithAudioSamplingRate(48000);
                options.WithAudioCodec(AudioCodec.LibMp3Lame);
                options.WithCustomArgument("-ac 2");
            })
            .ProcessAsynchronously();

    return memoryStream;
}

static async Task<Stream> PipeBroken3Async()
{
    using var file = File.Open(RAW_PATH, FileMode.Open);

    var memoryStream = new MemoryStream();

    // Try convert to opus
    await FFMpegArguments
            .FromPipeInput(new StreamPipeSource(file))
            .OutputToPipe(new StreamPipeSink(memoryStream), options =>
            {
                options.WithAudioSamplingRate(48000);
                options.WithAudioCodec("libopus");
                options.WithCustomArgument("-ac 2");
            })
            .ProcessAsynchronously();

    return memoryStream;
}

static async Task<Stream> WorkingPipeAsync()
{
    using var file = File.Open(MP3_PATH, FileMode.Open);

    var memoryStream = new MemoryStream();

    // Try convert to opus
    await FFMpegArguments
            .FromPipeInput(new StreamPipeSource(file))
            .OutputToPipe(new StreamPipeSink(memoryStream), options =>
            {
                options.WithAudioSamplingRate(48000);
                options.WithCustomArgument("-ac 2 -f s16le");
            })
            .ProcessAsynchronously();

    return memoryStream;
}
