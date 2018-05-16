using AutoMapper;
using Park.Data.Infrastructure;
using Park.Data.Repositories;
using Park.Entities;
using Park.Services.Abstract;
using Park.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park.Services
{
    public class RateService : IRateService
    {
        private readonly IEntityBaseRepository<ParkingSchedule> _parkingscheduleRepository;
        private readonly IUnitOfWork _unitOfWork;
        public RateService(IEntityBaseRepository<ParkingSchedule> parkingscheduleRepository,
         IUnitOfWork unitOfWork)
        {
            _parkingscheduleRepository = parkingscheduleRepository;
            _unitOfWork = unitOfWork;
        }

        public ResponseViewModel SaveParkingSchedule(ParkingScheduleViewModel parkingScheduleViewModel)
        {
            try
            {
                var obj = Mapper.Map<ParkingScheduleViewModel, ParkingSchedule>(parkingScheduleViewModel);
                if (obj.ID == 0)
                    _parkingscheduleRepository.Add(obj);
                else
                    _parkingscheduleRepository.Edit(obj);
                _unitOfWork.Commit();

                ResponseViewModel response = new ResponseViewModel()
                {
                    message = Contants.Success,
                    status = 1,
                    responseData = ""
                };
                return response;
            }
            catch (Exception)
            {
                ResponseViewModel response = new ResponseViewModel()
                {
                    message = Contants.Warning,
                    status = 3,
                    responseData = ""
                };
                return response;
            }

        }

        public ResponseViewModel DeleteParkingSchedule(long ParkingScheduleId)
        {
            try
            {
                ParkingSchedule obj = _parkingscheduleRepository.GetSingle(ParkingScheduleId);
                obj.IsDeleted = true;
                _parkingscheduleRepository.Edit(obj);
                _unitOfWork.Commit();
                ResponseViewModel response = new ResponseViewModel()
                {
                    message = Contants.Delete,
                    status = 2,
                    responseData = ""
                };
                return response;
            }
            catch (Exception)
            {
                ResponseViewModel response = new ResponseViewModel()
                {
                    message = Contants.Warning,
                    status = 3,
                    responseData = ""
                };
                return response;
            }
        }

    }
}
