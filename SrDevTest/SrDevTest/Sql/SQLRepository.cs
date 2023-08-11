using System;
using SQLite;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;
using System.Linq;
using SrDevTest.Models;

namespace SrDevTest.Sql
{
	public class SQLRepository
	{
          public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public bool initialized = false;
        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return System.IO.Path.Combine(basePath, "SrDevTest.db3");
            }
        }
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(DatabasePath, Flags);
        });
        public SQLiteAsyncConnection _db => lazyInitializer.Value;
        public async Task CheckAndCreateOrUpdateDatabaseTable(Type type)
        {
            try
            {
                if (!_db.TableMappings.Any(m => m.MappedType.Name == type.Name))
                {
                    await _db.CreateTablesAsync(CreateFlags.None, type);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task InitializeAsync()
        {
            try
            {
                if (!initialized)
                {
                    await CheckAndCreateOrUpdateDatabaseTable(typeof(NetworkInfoModel));
                    await CheckAndCreateOrUpdateDatabaseTable(typeof(UserModel));

                    initialized = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<int> Insert<T>(T entity)
        {
            try
            {
                if (_db != null)
                    await _db.InsertAsync(entity);
                return 1;
            }
            catch (SQLiteException )
            {
                throw;
            }
        }
        public async Task<int> InsertAll<T>(List<T> entityList)
        {
            try
            {
                if (_db != null)
                    await _db.InsertAllAsync(entityList);
                return 1;
            }
            catch (SQLiteException )
            {
               throw;
            }
        }
        public async Task<int> Update<T>(T entity)
        {
            try
            {
                if (_db != null)
                    await _db.UpdateAsync(entity);
                return 1;
            }
            catch (SQLiteException)
            {
                throw;
            }
        }
        public async Task<int> UpdateAll<T>(List<T> entityList)
        {
            try
            {
                if (_db != null)
                    await _db.UpdateAllAsync(entityList);
                return 1;
            }
            catch (SQLiteException)
            {
                throw;
            }
        }
        public async Task<int> Delete<T>(T entity)
        {
            try
            {
                if (_db != null)
                    await _db.DeleteAsync(entity);
                return 1;
            }
            catch (SQLiteException)
            {
                throw;
            }
        }
        public async Task<int> DeleteAll<T>()
        {
            try
            {
                if (_db != null)
                    await _db.DeleteAllAsync<T>();
                return 1;
            }
            catch (SQLiteException)
            {
                throw;
            }
        }
       
    }
}

