using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToDooo.Models;
using ToDooo.Utility;

namespace ToDooo.Controllers {
	public class UsersController : ApiController {
		ToDoooDbContext db = new ToDoooDbContext();

		[HttpGet]
		[ActionName("List")]
		public JsonResponse List() {
			var users = db.Users.ToList();
			return new JsonResponse {
				Data = users
			};
		}

		[HttpGet]
		[ActionName("Get")]
		public JsonResponse Get(int? Id) {
			if (Id == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Get needs a valid Id"
				};
			}
			var user = db.Users.Find(Id);
			if (user == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "That user does not exist"
				};
			}
			return new JsonResponse {
				Data = user
			};
		}

		[HttpPost]
		[ActionName("Create")]
		public JsonResponse Create(User user) {
			if (user == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Create needs a valid user"
				};
			}
			if (!ModelState.IsValid) {
				return new JsonResponse {
					Result = "Failed",
					Message = "One of the properties is not valid"
				};
			}
			db.Users.Add(user);
			db.SaveChanges();
			return new JsonResponse();
		}

		[HttpPost]
		[ActionName("Change")]
		public JsonResponse Change(User user) {
			if (user == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Create needs a valid user"
				};
			}
			if (!ModelState.IsValid) {
				return new JsonResponse {
					Result = "Failed",
					Message = "One of the properties is not valid"
				};
			}
			db.Entry(user).State = EntityState.Modified;
			db.SaveChanges();
			return new JsonResponse {
				Data = user
			};
		}

		[HttpPost]
		[ActionName("Remove")]
		public JsonResponse Remove(User user) {
			if (user == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Remove needs a valid user"
				};
			}
			var _user = db.Users.Find(user.Id);
			if(_user == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "That user does not exist"
				};
			}
			db.Users.Remove(_user);
			db.SaveChanges();
			return new JsonResponse();
		}

		[HttpPost]
		[ActionName("RemoveById")]
		public JsonResponse RemoveById(int? Id) {
			if (Id == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "RemoveById needs a valid Id"
				};
			}
			var _user = db.Users.Find(Id);
			if (_user == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "That user does not exist"
				};
			}
			db.Users.Remove(_user);
			db.SaveChanges();
			return new JsonResponse();
		}
	}
}
