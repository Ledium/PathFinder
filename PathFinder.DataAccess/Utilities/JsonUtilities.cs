using PathFinder.DataAccess.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace PathFinder.DataAccess.Utilities
{
    public class JsonUtilities
    {
        private JsonSerializerOptions _options;
        private ICollection<PathEntity> _data;

        public JsonUtilities()
        {
            _options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            _data = LoadData();
        }
        public IEnumerable<PathEntity> GetData()
        {
            return _data;
        }

        public PathEntity GetData(int id)
        {
            var entity = _data
                .Where(x => x.Id == id)
                .FirstOrDefault();

            return entity;
        }

        public PathEntity InsertData(PathEntity entity)
        {

            int id = _data.Count;
            entity.Id = ++id;

            bool check = CheckIfExists(entity.Value);

            if (check)
            {
                return _data
                    .Where(x => x.Value.SequenceEqual(entity.Value))
                    .FirstOrDefault();
            } 
            else
            {
                _data.Add(entity);

                var jsonData = JsonSerializer
                    .Serialize(_data, _options);

                File.WriteAllText("data.json", jsonData);

                return entity;
            }
        }

        public  ICollection<PathEntity> LoadData()
        {
            var jsonString = File.ReadAllText(@"data.json");

            var dataResult = new List<PathEntity>();

            if (!string.IsNullOrEmpty(jsonString))
            {
               dataResult = JsonSerializer
                    .Deserialize<List<PathEntity>>
                    (jsonString, _options)
                    .ToList();
            }

            return dataResult;
        }

        public bool CheckIfExists(int[] input)
        {
            var result = false;

            var entries = _data
                .Where(x => x.Value.SequenceEqual(input))
                .ToList();

            if (entries.Count > 0)
                result = true;

            return result;
        }
    }
}
