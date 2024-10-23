using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsNew.Application.DTOs;
using WhatsNew.Application.Models;

namespace WhatsNew.Application.Services.Interfaces
{
    public interface IFeatureService
    {
        Task<FeatureDTO> GetFeatureAsync(int id);
		Task<IEnumerable<Feature>> GetFeaturesByAnnouncementAsync(int announcementId);
		Task<IEnumerable<FeatureDTO>> FilterFeatures(int roleTagId = 0, int topicTagId = 0);
        Task<Feature> CreateFeatureAsync(FeatureDTO feature);
		Task<Feature> UpdateFeatureAsync(FeatureDTO feature);
		Task<bool> DeleteFeatureAsync(int id);
        Task<FeatureDTO> GetLatestFeatureAsync();
    }
}
