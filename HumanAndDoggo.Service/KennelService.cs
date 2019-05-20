using HumanAndDoggo.Data;
using HumanAndDoggo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanAndDoggo.Service
{
    public class KennelService
    {
        public bool CreateKennel(KennelCreate kennelCreate)
        {
            Kennel kennel = new Kennel
            {
                KennelNumber = kennelCreate.KennelNumber,
                Size = kennelCreate.Size,
                Occupied = kennelCreate.Occupied,
                DoggoID = kennelCreate.DoggoID,
                DoggoName = kennelCreate.DoggoName,

                //FullName = kennelCreate.FullName,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Kennels.Add(kennel);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<KennelListItem> GetKennels()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Kennels
                        .Select(
                            p =>
                                new KennelListItem
                                {
                                    KennelID = p.KennelID,
                                    KennelNumber = p.KennelNumber,
                                    Occupied = p.Occupied,
                                    FullName = p.FullName,
                                    Size = p.Size,
                                    DoggoID = ctx.Doggos.FirstOrDefault(c => c.DoggoID == p.DoggoID).DoggoName,
                                });
                return query.ToArray();
            }
        }
        public KennelListItem GetKennelByNumber(int kennelID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Kennels
                    .Single(e => e.KennelID == kennelID);
                return
                    new KennelListItem
                    {
                        KennelID = entity.KennelID,
                        KennelNumber = entity.KennelNumber,
                        FullName = entity.FullName,
                        Occupied = entity.Occupied,
                        Size = entity.Size,
                        DoggoID = ctx.Doggos.FirstOrDefault(c => c.DoggoID == entity.DoggoID).DoggoName,
                    };
            }
        }
        public bool UpdateKennel(KennelEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Kennels
                        .Single(e => e.KennelID == model.KennelID);
                entity.KennelNumber = model.KennelNumber;
                entity.KennelID = model.KennelID;
                entity.Occupied = model.Occupied;
                entity.DoggoID = model.DoggoID;
                entity.DoggoName = model.DoggoName;
                entity.Size = model.Size;
                entity.FullName = model.FullName;
              

                return ctx.SaveChanges() == 1;
            }
        }
        public bool KillKennel(int kennelID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Kennels
                        .Single(e => e.KennelID == kennelID);
                ctx.Kennels.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
