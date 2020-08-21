using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yiran.Areas.Admin.Models.Entity;
using yiran.Areas.Admin.Models.Request;
using yiran.Areas.Admin.Models.Response;
using yiran.Models.Entity;
using yiran.Areas.Admin.Common;
using MimeKit;
using MailKit.Net.Smtp;

namespace yiran.Areas.Admin.Service
{
    public class sys_FormService : DataContext
    {
        /// <summary>
        /// 分页获取表单信息
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="wheres"></param>
        /// <returns></returns>
        public async Task<PageRequestModel> GetFormPage(int pageIndex, int pageSize, string wheres)
        {
            var query = await Db.Ado.SqlQueryAsync<yr_form>($"SELECT f.id,f.name,f.phone,f.email,f.msg,f.addtime,f.Static,f.remark,u.name as uname FROM yr_form f left join sys_user u on f.remark_user = u.id {wheres} order by addtime DESC limit {(pageIndex - 1) * pageSize},{pageSize}");
            var total = await Db.Ado.GetIntAsync($"SELECT count(id) FROM yr_form f {wheres}");
            var PageModel = new PageRequestModel
            {
                code = 200,
                result = "分页获取成功",
                active = pageIndex,
                data = query,
                total = total
            };
            return PageModel;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponseModel> Delform(int[] id)
        {
            var query = await Db.Deleteable<yr_form>().In(id).ExecuteCommandAsync();
            if (query>=1) {
                return new ResponseModel { code = 200, result = "删除成功~" };
            }
            return new ResponseModel { code = 0, result = "删除失败~" };
        }
        /// <summary>
        /// 设置状态
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public async Task<ResponseModel> ShowForm(int[] id,HttpContext context)
        {
            var session = context.Session.Get<sys_user>("yr_user");
            List<ShowFormModel> data = new List<ShowFormModel>();
            foreach (var i in id)
            {
                data.Add(new ShowFormModel
                {
                    id = i,
                    Static = 1,
                    remark = $"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} 设置已查看",
                    remark_user = session.id
                });
            }
            var query = await Db.Updateable(data).ExecuteCommandAsync();
            if (query >= 1)
            {
                return new ResponseModel { code = 200, result = "更新成功~" };
            }
            return new ResponseModel { code = 0, result = "更新失败~" };
        }
        /// <summary>
        /// 根据id返回一条form
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<yr_form> GetFormByid(int id)
        {
            var query = await Db.Queryable<yr_form>().In(id).SingleAsync();
            return query;
        }
        public async Task<ResponseModel> Subform(Subform form,HttpContext context)
        {
            try
            {
                var emailInfo = await Db.Queryable<sys_email>().In(1).SingleAsync();
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(emailInfo.name, emailInfo.email)); //发件者信息
                message.To.Add(new MailboxAddress(form.name, form.email)); //收件人信息
                message.Subject = form.title; //标题
                var bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = @form.content;
                message.Body = bodyBuilder.ToMessageBody();
                using (var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    var ssl = emailInfo.isssl == 1 ? true : false;
                    await client.ConnectAsync(emailInfo.host, emailInfo.prot, ssl);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(emailInfo.email, emailInfo.password);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
                string remark = $"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} 回复信息";
                int userId = context.Session.Get<sys_user>("yr_user").id;
                await Db.Updateable<yr_form>().Where(c => c.id == form.id).UpdateColumns(c => new yr_form { Static = 2, remark = remark, remark_user = userId }).ExecuteCommandAsync();
                return new ResponseModel { code = 200, result = "发送成功~" };
            }
            catch {
                return new ResponseModel { code = 0, result = "发送失败~" };
            }
        }
    }
}
