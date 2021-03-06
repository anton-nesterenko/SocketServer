﻿using System;
using System.Linq;
using SocketServer.Data;
using Zone = SocketServer.Data.Zone;

namespace SocketServer.Repository
{
    public class ZoneRepository : IDataRepository<Zone>, IDisposable
    {
        private readonly ServerDataEntities _context;

        private static ZoneRepository _instance;

        public static ZoneRepository Instance
        {
            get { return _instance ?? (_instance = new ZoneRepository()); }
        }

        #region ctor
        protected ZoneRepository()
            : this(DatabaseContextFactory.Context)
        {
        }

        protected ZoneRepository(ServerDataEntities context)
        {
            _context = context;
        }
        #endregion

        public Zone Find(long id)
        {
            return _context.Zones.
                Where(z => z.Id == id).
                FirstOrDefault();
        }

        public Zone[] GetAll()
        {
            return _context.Zones.ToArray();
        }

        public IQueryable<Zone> Query(System.Linq.Expressions.Expression<Func<Zone, bool>> filter)
        {
            return _context.Zones.Where(filter);
        }

        public void Add(Zone value)
        {
            _context.AddToZones(value);
            _context.SaveChanges();
        }

        public void Delete(Zone value)
        {
            _context.DeleteObject(value);
            _context.SaveChanges();
        }

        public void Update(Zone value)
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }

            GC.SuppressFinalize(this);
        }
    }
}
