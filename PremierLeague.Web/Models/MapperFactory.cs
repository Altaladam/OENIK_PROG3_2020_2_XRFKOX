// <copyright file="MapperFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PremierLeague.Web.Models
{
    using AutoMapper;

    /// <summary>
    /// A factory for the mapper.
    /// </summary>
    public static class MapperFactory
    {
        /// <summary>
        /// Creates a mapper.
        /// </summary>
        /// <returns>Returns the created mapper.</returns>
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Web.Models.Player, Data.Player>().
                    ForMember(dest => dest.PlayerID, map => map.MapFrom(src => src.Id)).ReverseMap();
            });
            return config.CreateMapper();
        }
    }
}
