using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ComicBookGallery.Models;

namespace ComicBookGallery.Data
{
    public class SeriesRepository
    {
        public Series[] GetSeries()
        {
            return Data.Series;
        }

        public Series GetSeriesDetail(int ID)
        {
            Series seriesToReturn = null;
            

            foreach (var series in Data.Series)
            {
                if (series.ID == ID)
                {
                    seriesToReturn = series;
                    break;
                }
            }

            if(seriesToReturn != null)
            {
                var comicBooks = new ComicBook[0];

                foreach (var comicBook in Data.ComicBooks)
                {
                    if (comicBook.Series != null && comicBook.Series.ID == ID)
                    {
                        Array.Resize(ref comicBooks, comicBooks.Length + 1);
                        comicBooks[comicBooks.Length - 1] = comicBook;
                    }
                }
                seriesToReturn.Issues = comicBooks;

                
                 

            }
            return seriesToReturn;
        }

    
    }
}