using System.Collections.Generic;

namespace Pj.CoreLayer.Entities
{
    public class Tag
    {
        // tag_id (PK IDENTITY)
        public int Id { get; set; }

        // tag_name (NOT NULL, UNIQUE)
        public string TagName { get; set; }

        // Quan hệ n-n với Movie qua bảng MovieSeriesTags
        public ICollection<MovieSeriesTag> MovieSeriesTags { get; set; }
    }
}
