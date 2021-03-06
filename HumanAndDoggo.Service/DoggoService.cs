﻿using HumanAndDoggo.Data;
using HumanAndDoggo.Model;
using System.Collections.Generic;
using System.Linq;

namespace HumanAndDoggo.Service
{
    public class DoggoService
    {
        public bool Create(DoggoCreate doggoCreate)
        {
            var entity = new Doggo
            {
                DoggoName = doggoCreate.DoggoName,
                Breed = doggoCreate.Breed,
                Size = doggoCreate.Size,
                HumanID = doggoCreate.HumanID,
                DoggoFriendly = doggoCreate.DoggoFriendly,
                PeopleFriendly = doggoCreate.PeopleFriendly,
                SpecialNeeds = doggoCreate.SpecialNeeds,
                Age = doggoCreate.Age,
                Image = doggoCreate.Image
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Doggos.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<DoggoListItem> GetDoggos()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Doggos
                        .Select(
                            p =>
                               new DoggoListItem
                               {
                                   DoggoID = p.DoggoID,
                                   DoggoName = p.DoggoName,
                                   Breed = p.Breed,
                                   Size = p.Size,
                                   HumanID = ctx.Humans.FirstOrDefault(c => c.HumanID == p.HumanID).FullName,
                                   DoggoFriendly = p.DoggoFriendly,
                                   PeopleFriendly = p.PeopleFriendly,
                                   SpecialNeeds = p.SpecialNeeds,
                                   Age = p.Age,
                                   Image = p.Image
                               }
                               );

                return query.ToArray();
            }
        }

        public DoggoListItem GetDoggoById(int doggoID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Doggos
                    .Single(e => e.DoggoID == doggoID);
                return
                    new DoggoListItem
                    {
                        DoggoID = entity.DoggoID,
                        DoggoName = entity.DoggoName,
                        Breed = entity.Breed,
                        Size = entity.Size,
                        HumanID = ctx.Humans.FirstOrDefault(c => c.HumanID == entity.HumanID).FullName,
                        DoggoFriendly = entity.DoggoFriendly,
                        PeopleFriendly = entity.PeopleFriendly,
                        SpecialNeeds = entity.SpecialNeeds,
                        Age = entity.Age,
                        Image = entity.Image
                    };
            }
        }

        public bool UpdateDog(DoggoEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Doggos
                        .Single(e => e.DoggoID == model.DoggoID);

                entity.DoggoName = model.DoggoName;
                entity.Breed = model.Breed;
                entity.Size = model.Size;
                entity.DoggoFriendly = model.DoggoFriendly;
                entity.PeopleFriendly = model.PeopleFriendly;
                entity.SpecialNeeds = model.SpecialNeeds;
                entity.Age = model.Age;
                entity.Image = model.Image;


                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteDog(int doggoID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Doggos
                        .Single(e => e.DoggoID == doggoID);

                ctx.Doggos.Remove(entity);
                return ctx.SaveChanges() == 1;


            }
        }
    }
}
