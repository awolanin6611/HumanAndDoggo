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
        public bool Create(KennelCreate kennelCreate)
        {
            Kennel kennel = new Kennel
            {
                KennelNumber = kennelCreate.KennelNumber,
                Size = kennelCreate.Size,
                Occupied = kennelCreate.Occupied
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
                                    KennelNumber = p.KennelNumber,
                                    Occupied = p.Occupied,
                                    DoggoName = p.DoggoName,
                                    FullName = p.FullName
                                });
                return query.ToArray();
            }
        }
        public KennelListItem GetKennelByNumber(int kennelNumber)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Kennels
                    .Single(e => e.KennelNumber == kennelNumber);
                return
                    new KennelListItem
                    {
                        KennelID = entity.KennelID,
                        KennelNumber = entity.KennelNumber,
                        DoggoName = entity.DoggoName,
                        FullName = entity.FullName,
                        Occupied = entity.Occupied
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
                entity.KennelID = model.KennelID;
                entity.Occupied = model.Occupied;
                entity.DoggoID = model.DoggoID;
                entity.DoggoName = model.DoggoName;
                entity.HumanID = model.HumanID;
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
