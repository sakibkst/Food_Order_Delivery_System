﻿using al.Auth;
using BLL.ModelDTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.Http;

namespace al.Controllers
{
    public class ChatController : ApiController
    {
        [Logged]
        [TwoRole("User", "Admin")]
        [HttpGet]
        [Route("api/chats")]
        public HttpResponseMessage AllChat()
        {
            try
            {
                var data = ChatService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/chats/{id}")]
        public HttpResponseMessage GetOneChat(int id)
        {
            try
            {
                var data = ChatService.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPost]
        [Route("api/chat/create")]
        public HttpResponseMessage CreateChat(ChatDto chatDto)
        {
            try
            {
                var data = ChatService.Create(chatDto);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPost]
        [Route("api/chats/update")]
        public HttpResponseMessage UpdateChat(ChatDto chatDto)
        {
            try
            {
                var data = ChatService.Update(chatDto);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/chats/delete/{id}")]
        public HttpResponseMessage DeleteChat(int id)
        {
            try
            {
                var data = ChatService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpGet]
        [Route("api/chats/getbyids/{uid}/{did}")]
        public HttpResponseMessage GetByIds(int uid, int did)
        {
            try
            {
                var data = ChatService.GetChat(uid, did);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpGet]
        [Route("api/chats/getbymsg/{msg}/{uid}/{did}")]
        public HttpResponseMessage GetByMsg(string msg, int uid, int did)
        {
            try
            {
                var data = ChatService.GetByMsg(msg, uid, did);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}