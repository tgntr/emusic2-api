﻿using SimpleMusicStore.Contracts.Repositories;
using SimpleMusicStore.Contracts.Services;
using SimpleMusicStore.Contracts.Validators;
using SimpleMusicStore.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMusicStore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SimpleMusicStoreDbContext _db;

        public UnitOfWork(SimpleMusicStoreDbContext db,
            IAddressRepository addresses,
            IArtistFollowRepository artistFollows,
            IArtistRepository artists,
            ILabelFollowRepository labelFollows,
            ILabelRepository labels,
            IOrderRepository orders,
            IRecordRepository records,
            IWishRepository wishes,
            IUserRepository users,
            //ICurrentUserActivities currentUser,
            //IServiceValidator validator,
            IStockRepository stocks)
        {
            _db = db;
            Addresses = addresses;
            ArtistFollows = artistFollows;
            Artists = artists;
            LabelFollows = labelFollows;
            Labels = labels;
            Orders = orders;
            Records = records;
            Wishes = wishes;
            Users = users;
            //CurrentUser = currentUser;
            //Validator = validator;
            Stocks = stocks;
        }

        public IAddressRepository Addresses { get; }
        public IArtistFollowRepository ArtistFollows { get; }
        public IArtistRepository Artists { get; }
        public ILabelFollowRepository LabelFollows { get; }
        public ILabelRepository Labels { get; }
        public IOrderRepository Orders { get; }
        public IRecordRepository Records { get; }
        public IWishRepository Wishes { get; }
        public IUserRepository Users { get; }
        //public ICurrentUserActivities CurrentUser { get; }
        //public IServiceValidator Validator { get; }
        public IStockRepository Stocks { get; }

        public Task SaveChanges()
        {
            return _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}