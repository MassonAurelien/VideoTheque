using Microsoft.EntityFrameworkCore;
using VideoTheque.Context;
using VideoTheque.DTOs;
using VideoTheque.Constants;
using static System.Enum;
using System.Collections.Generic;

namespace VideoTheque.Repositories.Supports
{
    public class SupportsRepository : ISupportsRepository
    {

        public List<SupportsDto> GetSupports()
        {
            List<SupportsDto> result = new List<SupportsDto>();

            foreach (string support in Enum.GetNames(typeof(EnumSupports)))
            {
                SupportsDto supportDto = new SupportsDto();
                supportDto.Name = support;
                supportDto.Id = (int)Enum.Parse(typeof(EnumSupports), support);
                result.Add(supportDto);
            }
            return result;
        }

        public SupportsDto GetSupport(int id)
        {
            SupportsDto supportDto = new SupportsDto();
            supportDto.Name = Enum.GetName(typeof(EnumSupports), id);
            supportDto.Id = id;
            return supportDto;
        }

    }   
}
