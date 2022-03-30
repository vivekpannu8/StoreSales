using System;

namespace DemoProject
{
    class VideoEncoder
    {
        public delegate void CustomEventHandler(Object sender, EventArgs e); 
        public void EncodeVideo(Video video)
        {
            Console.WriteLine("Encoding Video ....");

            VideoEncoded();
        }

        public void VideoEncoded()
        {

        }
    }
    class Video
    {
        public string videoTitle { get; set; }
    }
    internal class Program
    {
        static void Main()
        {
            Video video = new Video();
            video.videoTitle = "First Video";
            Console.WriteLine("Hello World!");
        }
    }
}
