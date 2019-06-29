using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using templateExamen.Models;
using templateExamen.ViewModels;

namespace templateExamen.Services
{
        public interface IPachetService
        {
            PachetGetModel GetById(int id);
            PachetGetModel Delete(int id);
            IEnumerable<PachetGetModel> GetAll();
            Pachet Create(PachetPostModel pachetPostModel);
            PachetGetModel Upsert(int id, PachetPostModel pachetPostModel);
          
        }

        public class PachetService : IPachetService
        {
            private UsersDbContext context;

            public PachetService(UsersDbContext context)
            {
                this.context = context;
            }

            public Pachet Create(PachetPostModel pachetPostModel)
            {
                Pachet toAdd = PachetPostModel.ToPachet(pachetPostModel);
                context.Pachets.Add(toAdd);
                context.SaveChanges();
                return toAdd;
            }

            public PachetGetModel Delete(int id)
            {
                var existing = context
                     .Pachets
                     .FirstOrDefault(uRole => uRole.Id == id);
                if (existing == null)
                {
                    return null;
                }

                context.Pachets.Remove(existing);
                context.SaveChanges();

                return PachetGetModel.FromPachet(existing);
            }

            public IEnumerable<PachetGetModel> GetAll()
            {
                return context
                .Pachets
                .OrderByDescending(p => p.Cost)
                .Select(pachet => PachetGetModel.FromPachet(pachet));
            }

            public PachetGetModel GetById(int id)
            {
                Pachet pachet = context
                    .Pachets
                    .AsNoTracking()
                    .FirstOrDefault(p => p.Id == id);

                return PachetGetModel.FromPachet(pachet);
            }

    

        public PachetGetModel Upsert(int id, PachetPostModel pachetPostModel)
            {
                var existing = context.Pachets.AsNoTracking().FirstOrDefault(pachet => pachet.Id == id);
                if (existing == null)
                {

                    Pachet toAdd = PachetPostModel.ToPachet(pachetPostModel);
                    context.Pachets.Add(toAdd);
                    context.SaveChanges();
                    return PachetGetModel.FromPachet(toAdd);
                }

                Pachet Update = PachetPostModel.ToPachet(pachetPostModel);
                Update.Id = id;
                context.Pachets.Update(Update);
                context.SaveChanges();
                return PachetGetModel.FromPachet(Update);
            }
        }
    }

