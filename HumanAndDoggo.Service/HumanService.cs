using HumanAndDoggo.Data;
using HumanAndDoggo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanAndDoggo.Service
{
    public class HumanService
    {
        public bool Create(HumanCreate humanCreate)
        {
            var entity = new Human()
            {
                FullName = humanCreate.FullName,
                Address = humanCreate.Address,
                Phone = humanCreate.Phone,
                Email = humanCreate.Email

            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Humans.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<HumanListItem> GetHumans()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Humans
                    .Select(
                        p =>
                        new HumanListItem
                        {
                            HumanID = p.HumanID,
                            FullName = p.FullName,
                            Address = p.Address,
                            Email = p.Email,
                            Phone = p.Phone,
                            DoggoName = p.DoggoName
                        }
                        );
                return query.ToArray();
            }
        }
        public HumanListItem GetHumanById(int humanID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Humans
                    .Single(e => e.HumanID == humanID);
                return
                    new HumanListItem
                    {
                        HumanID = entity.HumanID,
                        FullName = entity.FullName,
                        Address = entity.Address,
                        Phone = entity.Phone,
                        Email = entity.Email,
                        DoggoName = entity.DoggoName
                    };
            }
        }
        public bool UpdateHuman(HumanEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Humans
                    .Single(e => e.HumanID == model.HumanID);
                entity.FullName = model.FullName;
                entity.Address = model.Address;
                entity.Phone = model.Phone;
                entity.Email = model.Email;
                entity.DoggoName = model.DoggoName;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteHuman(int humanID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Humans
                    .Single(e => e.HumanID == humanID);
                ctx.Humans.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
