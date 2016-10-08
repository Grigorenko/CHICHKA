using CHICHKA.Models;
using Model.Context;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CHICHKA.Controllers
{
    public class RegistrationController : ApiController
    {
        ChichkaContext db;
        public RegistrationController()
        {
            db = new ChichkaContext();
        }

        [HttpPost]
        public string AddUser(Registration registration)
        {
            try
            {
                string status = "";
                if (registration != null)
                {
                    if(!CheckingData(registration, ref status))
                    {
                        return status;
                    }
                    else
                    {
                        if (GetUser(registration))
                        {
                            db.Users.Add(new User() {
                                UserName = registration.UserName,
                                SubUserName = registration.SubUserName,
                                SubUserPassword = registration.SubUserPassword,
                                UserPassword = registration.UserPassword
                            });
                            db.SaveChanges();
                            db.Wallets.Add(new Wallet() {
                                CardNumber = registration.CardNumber,
                                YearExpire = registration.YearExpire,
                                MonthExpire = registration.MonthExpire,
                                CW2 = registration.CW2
                            });
                            db.SaveChanges();
                            db.Accounts.Add(new Account() {
                                User = db.Users.FirstOrDefault(u => u.UserName == registration.UserName),
                                Wallet = db.Wallets.Where(cn => cn.CardNumber == registration.CardNumber).
                                                    FirstOrDefault(cw => cw.CW2 == registration.CW2),
                                Balance = 0
                            });
                            db.SaveChanges();
                            return registration.UserName;
                        }
                        return "UserName bisy";
                    }
                }
                else
                {
                    return "Empty entity";
                }
                
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private bool CheckingData(Registration registration, ref string status)
        {
            bool flag = true;
            status = "";
            if (registration.UserName == null)
            {
                status += "UserName empty\n";
                flag = false;
            }
            if (registration.UserPassword == null)
            {
                status += "UserPassword empty\n";
                flag = false;
            }
            if (registration.SubUserName == null)
            {
                status += "SubUserName empty\n";
                flag = false;
            }
            if (registration.SubUserPassword == null)
            {
                status += "SubUserPassword empty\n";
                flag = false;
            }
            if (registration.CardNumber == null)
            {
                status += "CardNumber empty\n";
                flag = false;
            }
            if (registration.YearExpire == 0)
            {
                status += "YearExpire empty\n";
                flag = false;
            }
            if (registration.MonthExpire == 0)
            {
                status += "MonthExpire empty\n";
                flag = false;
            }
            if (registration.CW2 == null)
            {
                status += "CW2 empty\n";
                flag = false;
            }
            
            return flag;
        }

        private bool GetUser(Registration registration)
        {
            User temp =  db.Users.FirstOrDefault(x => x.UserName == registration.UserName);
            if (temp != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
