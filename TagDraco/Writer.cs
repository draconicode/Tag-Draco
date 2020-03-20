﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TagLib;

namespace TagDraco
{
    class Writer
    {
        const string TEMP_FILE_NAME = "tagDracoTemp.png";
        public bool SaveMetadataToFile(TagLib.File file, string title, string album, string[] albumArtists, int track, int year, string[] genres, string[] artists, Image picFile, int index)
        {
            try {
                Tag tags = file.Tag;

                tags.Title = title;
                tags.Album = album;
                tags.AlbumArtists = albumArtists;
                tags.Performers = artists;
                tags.Track = (uint)track;
                tags.Genres = genres;
                tags.Year = (uint)year;
                string fileName = System.IO.Path.GetTempPath() + TEMP_FILE_NAME;
                picFile.Save(Path.GetTempPath() + TEMP_FILE_NAME, ImageFormat.Png);
                Picture[] picture = new Picture[1];
                picture[0] = new Picture(fileName);
                tags.Pictures = picture;
                TagDraco.metaData[index] = tags;
                file.Save();
                MessageBox.Show("Tags successfuly updated.", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                return false;
            }
            
        }
    }
}
