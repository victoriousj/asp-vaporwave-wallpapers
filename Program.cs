using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace VaporWallpaper
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();

            var vaporWaveWallpaperFolder = new DirectoryInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Wallpapers"));

            var fileCount = vaporWaveWallpaperFolder.GetFiles().Length;

            var vaporWaveWallpaperFileInfos = vaporWaveWallpaperFolder.GetFiles();

            var vaporWaveWallpaperPaths = vaporWaveWallpaperFileInfos.Select(x => x.FullName).ToList();

            var vaporWaveWallpaper = vaporWaveWallpaperPaths[random.Next(0, fileCount - 1)];

            ChangeWallpaper(vaporWaveWallpaper);

        }
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SystemParametersInfo
        (uint uiAction, uint uiParam, string pvParam, uint fWinIni);
        static void ChangeWallpaper(string vaporWaveWallpaper) => SystemParametersInfo(20, 1, vaporWaveWallpaper, 0x1);
    }
}
