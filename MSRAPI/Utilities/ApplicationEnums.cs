using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSR.CORE.Utilities
{
    public enum Status
    {
        Success = 0,
        Failed = 1,
        Warning = 2,
    }

    public enum UserRoles
    {
        Adnin = 1,
    }

    public enum AuthStatus
    {
        InvalidUser = 1,
        EmailNotConfirmed = 2,
        InActiveUser = 3,
        UnderImpersonation = 4,
        AccountLocked = 5,
        LoginFailed = 6,
        UnAuthorized = 7,
        TokenFailure = 8,
        NotOnboarded = 9,
        AcceptEULA = 10,
        TokenExpired = 11
    }
    public enum MonthEnum
    {
        NotSet = 0,
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12
    }
}
