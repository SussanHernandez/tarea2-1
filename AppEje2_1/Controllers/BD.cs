using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppEje2_1.Controllers
{
    public class BD
    {
        readonly SQLiteAsyncConnection db;
        public BD(String path)
        {
            db = new SQLiteAsyncConnection(path);
            db.CreateTableAsync<Models.Vid>().Wait();
        }
        # region metodos del video
        public Task<List<Models.Vid>> GetListVid()
        {
            return db.Table<Models.Vid>().ToListAsync();
        }
        public Task<Models.Vid> GetVideosporId(int id)
        {
            return db.Table<Models.Vid>()
                .Where(i => i.id == id)
                .FirstOrDefaultAsync();
        }
        public Task<int> guardaVideos(Models.Vid vid)
        {
            return vid.id != 0 ? db.UpdateAsync(vid) : db.InsertAsync(vid);
        }
        public Task<int> borrarVideo(Models.Vid vid)
        {
            return db.DeleteAsync(vid);
        }
        #endregion
    }
}
