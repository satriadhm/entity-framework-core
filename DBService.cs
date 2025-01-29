using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpImplementation
{
    internal class DBService : IDBRepository<DBModel>
    {

        private readonly AppDBContext _context;

        public DBService(AppDBContext context) 
        {
            _context = context;
        }
        public async Task Add(DBModel entity)
        {
            try 
            {
                await _context.DBModels.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteById(string id)
        {
            try
            {
                var entity = await _context.DBModels.FindAsync(id);
                if (entity == null)
                {
                    throw new Exception($"Entity with ID {id} not found.");
                }

                _context.DBModels.Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting entity: {ex.Message}");
            }
        }

        public Task<IEnumerable<DBModel>> GetAllSync()
        {
            throw new NotImplementedException();
        }

        public async Task<DBModel?> GetById(string id)
        {
            try 
            { 
                var model = await _context.DBModels.FindAsync(id);
                return model ?? throw new Exception($"Entity with ID {id} not found.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching entity by ID: {ex.Message}");
            }
        }

        public async Task Update(string id, DBModel Entity)
        {
            try 
            {
                var existingEntity = await _context.DBModels.FindAsync(id);
                _context.Entry(existingEntity).CurrentValues.SetValues(Entity);
                await _context.SaveChangesAsync();

            } catch(Exception ex) 
            {
                throw new Exception($"Error updating entity: {ex.Message}");
            }
        }
    }
}
