using Park.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park.Services.Abstract
{
    public interface IRateService
    {
        ResponseViewModel SaveParkingSchedule(ParkingScheduleViewModel parkingScheduleViewModel);
        ResponseViewModel DeleteParkingSchedule(long ParkingScheduleId);
    }
}
