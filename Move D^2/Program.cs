using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MOVE_D_2public
{
    class Program
    {
        static string[] mediaExtensions = {
          ".AVI", ".MP4", ".DIVX", ".WMV",".MKV",".avi", ".mp4", ".divx", ".wmv",".mkv"
        };

        static bool IsMediaFile(string path)
        {
            return mediaExtensions.Contains(Path.GetExtension(path), StringComparer.OrdinalIgnoreCase);
        }
        static void SwipeAndDelete(String[] array, int i, int leanth)
        {
            array[i] = array[leanth];
        }
        static String[] Cut(String[] array, int lenght)
        {
            String[] final = new String[lenght];
            for (int i = 0; i < lenght; i++)
            {
                final[i] = array[i];
            }
            return final;
        }
        static void Main(string[] args)
        {
            String path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] filesInfo = d.GetFiles();

            for (int i = 0; i < filesInfo.Length; i++)
            {
                String name = filesInfo[i].Name;
                String originalName = filesInfo[i].Name;
                if (IsMediaFile(name))
                {
                    for (int j = 0; j < mediaExtensions.Length; j++)
                    {
                        name = name.Replace(mediaExtensions[j], "");
                    }
                    Directory.CreateDirectory(path + "\\" + name);
                    filesInfo[i].CopyTo(path + "\\" + name + "\\" + originalName);
                }
            }
            Console.Read();
        }
    }
}
