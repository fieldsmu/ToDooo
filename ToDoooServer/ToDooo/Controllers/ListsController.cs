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
	public class ListsController : ApiController {
		ToDoooDbContext db = new ToDoooDbContext();

		[HttpGet]
		[ActionName("List")]
		public JsonResponse List() {
			var lists = db.Lists.ToList();
			return new JsonResponse {
				Data = lists
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
			var list = db.Lists.Find(Id);
			if (list == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "That list does not exist"
				};
			}
			return new JsonResponse {
				Data = list
			};
		}

		[HttpPost]
		[ActionName("Create")]
		public JsonResponse Create(List list) {
			if (list == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Create needs a valid list"
				};
			}
			if (!ModelState.IsValid) {
				return new JsonResponse {
					Result = "Failed",
					Message = "One of the properties is not valid"
				};
			}
			db.Lists.Add(list);
			db.SaveChanges();
			return new JsonResponse();
		}

		[HttpPost]
		[ActionName("Change")]
		public JsonResponse Change(List list) {
			if (list == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Create needs a valid list"
				};
			}
			if (!ModelState.IsValid) {
				return new JsonResponse {
					Result = "Failed",
					Message = "One of the properties is not valid"
				};
			}
			db.Entry(list).State = EntityState.Modified;
			db.SaveChanges();
			return new JsonResponse {
				Data = list
			};
		}

		[HttpPost]
		[ActionName("Remove")]
		public JsonResponse Remove(List list) {
			if (list == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Remove needs a valid list"
				};
			}
			var _list = db.Lists.Find(list.Id);
			if (_list == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "That list does not exist"
				};
			}
			db.Lists.Remove(_list);
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
			var _list = db.Lists.Find(Id);
			if (_list == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "That list does not exist"
				};
			}
			db.Lists.Remove(_list);
			db.SaveChanges();
			return new JsonResponse();
		}
	}
}
