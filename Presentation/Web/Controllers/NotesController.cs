using App.Interfaces;
using App.Models;
using Data.EF;
using Microsoft.AspNetCore.Mvc;
using Notes;
using Notes.Interfaces;
using Notes.ModelsDb;
using Services;
using System;
using Web.Models;

namespace Web.Controllers
{
    public class NotesController : Controller
    {

        private readonly INoteAppService _noteAppService;

        public NotesController(INoteAppService noteAppService)
        {
            _noteAppService = noteAppService;
        }

        // GET: /Notes/Index
        public async Task<IActionResult> Index()
        {
            var existingNotes = await _noteAppService.GetAllNotesAsync();
            ViewBag.ExistingNotes = existingNotes;
            var viewModel = new NoteListModel
            {
                Notes = new List<NoteDto> { new NoteDto() }
            };
            return View(viewModel);
        }

        // POST: /Notes/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(NoteListModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Iterate through list of items and add to the note
                    foreach (var noteDto in model.Notes)
                    {
                        await _noteAppService.CreateNoteAsync(noteDto.Title, noteDto.Content);
                    }

                    // Gets ALL notes after posting to noteAppService
                    var allNotes = await _noteAppService.GetAllNotesAsync();
                    ViewBag.ExistingNotes = allNotes; 
                    ModelState.Clear();
                    model.Notes = new List<NoteDto> { new NoteDto() }; 

                    ViewBag.SuccessMessage = "Заметки успешно сохранены!"; 
                    return View(model); 

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Произошла ошибка при создании заметок.");
                    // При возникновении ошибки возвращаем представление с моделью и ошибкой
                    return View(model);
                }
            }
            // Если модель не валидна, возвращаем представление с моделью и ошибками валидации
            return View(model);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            await _noteAppService.DeleteNoteAsync(id);
            return RedirectToAction("Index");
            
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Guid Id,string Title,string Content)
        {
            await _noteAppService.UpdateNoteAsync(Id, Title, Content);
            return RedirectToAction("Index");
        }
    }
}


   
