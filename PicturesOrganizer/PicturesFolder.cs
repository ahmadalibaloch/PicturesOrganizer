using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicturesOrganizer
{
    public class PicutresFolder
    {
        public string supportedExtensions = "*.jpg,*.gif,*.png,*.bmp,*.jpe,*.jpeg,*.wmf,*.avi,*.mp4,*.3gp,*.amr,*.wav,*.mp3";
        private DirectoryInfo picturesFolder;
        public PicutresFolder(string path)
        {
            this.picturesFolder = new DirectoryInfo(path);
        }
        public ArrayList getPictures()
        {
            ArrayList picturs = new ArrayList();
            //    var files = Directory.GetFiles(this.picturesFolder.FullName, "*.*", SearchOption.AllDirectories)
            //.Where(s => s.EndsWith(".bmp") || s.EndsWith(".jpg") || s.EndsWith(".jpeg") || s.EndsWith(".gif") || s.EndsWith(".png") || s.EndsWith(".avi") || s.EndsWith(".mp4") || s.EndsWith(".3gp"));
            //    foreach (String pic in files)
            //    {
            //        picturs.
            //    }
            foreach (string imageFile in Directory.GetFiles(this.picturesFolder.FullName, "*.*", SearchOption.AllDirectories).Where(s => supportedExtensions.Contains(Path.GetExtension(s).ToLower())))
            {
                picturs.Add(new FileInfo(imageFile));
            }
            return picturs;
        }
        public ArrayList getDirectories()
        {
            ArrayList directories = new ArrayList();
            foreach (DirectoryInfo directory in this.picturesFolder.GetDirectories())
            {
                directories.Add(new PicutresFolder(directory.FullName));
            }
            return directories;
        }
        /// <summary>
        /// Inner representation of this directory
        /// </summary>
        public DirectoryInfo Self
        {
            get
            {
                return this.picturesFolder;
            }
            set
            {
                this.picturesFolder = value;
            }
        }
        /// <summary>
        /// Gives the full path to the directory
        /// </summary>
        public string FullName { get { return this.picturesFolder.FullName; } }
    }
}
