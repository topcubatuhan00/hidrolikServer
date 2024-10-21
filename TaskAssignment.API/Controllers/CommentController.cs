using Microsoft.AspNetCore.Mvc;
using Hidrolik.Application.Services;
using Hidrolik.Domain.Models.CommentModels;
using Hidrolik.Domain.Models.HelperModels;

namespace Hidrolik.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentController : ControllerBase
{
    #region Fields
    private readonly ICommentService _commentService;
    #endregion

    #region Ctor
    public CommentController
    (
        ICommentService commentService
    )
    {
        _commentService = commentService;
    }
    #endregion

    #region Methods
    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateCommentModel model)
    {
        await _commentService.Create(model);
        return Ok("Yorum Başarıyla Eklendi");
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Update(UpdateCommentModel model)
    {
        await _commentService.Update(model);
        return Ok("Yorum Başarıyla Güncellendi");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove(int id)
    {
        await _commentService.Remove(id);
        return Ok("Yorum Başarıyla Kaldırıldı");
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAll([FromQuery] PaginationRequest request)
    {
        var result = await _commentService.GetAll(request);

        return Ok(result);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetComments([FromQuery] GetCommentModel model)
    {
        var result = await _commentService.GetComments(model);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _commentService.GetById(id);

        return Ok(result);
    }

    [HttpGet("User/{userId}")]
    public async Task<IActionResult> GetCommentsByUserId(int userId)
    {
        var result = await _commentService.GetCommentsByUserId(userId);

        return Ok(result);
    }
    #endregion
}
