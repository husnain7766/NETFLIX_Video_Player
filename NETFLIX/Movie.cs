using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETFLIX
{
    class Movie
    {
        private string _thumbnail;
        private string _moviesLink;
        private string _movieName;
        private string _category;

        public override string ToString()
        {
            return $"{nameof(_thumbnail)}: {_thumbnail}, {nameof(_moviesLink)}: {_moviesLink}, {nameof(_movieName)}: {_movieName}, {nameof(_category)}: {_category}, {nameof(_http)}: {_http}";
        }

        public Movie(string thumbnail, string moviesLink, string movieName, string category, bool http=false)
        {
            _thumbnail = thumbnail;
            _moviesLink = moviesLink;
            _movieName = movieName;
            _category = category;
            _http = http;
        }

        public string Category
        {
            get => _category;
            set => _category = value;
        }

        public string MovieName
        {
            get => _movieName;
            set => _movieName = value;
        }
        private bool _http;
        public string Thumbnail
        {
            get => _thumbnail;
            set => _thumbnail = value;
        }

        public string MoviesLink
        {
            get => _moviesLink;
            set => _moviesLink = value;
        }

        public bool Http
        {
            get => _http;
            set => _http = value;
        }
    }
}
