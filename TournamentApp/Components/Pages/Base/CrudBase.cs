using Microsoft.AspNetCore.Components.Forms;

namespace TournamentApp.Components.Pages;

public abstract class CrudBase: PageBase
{
    protected const int DefaultPageSize = 25;
    protected const int DefaultPage = 1;
    
    protected EditContext EditContext;
    protected bool DisplayModal;
    protected bool DisplayDeleteModal;
    protected bool DisplayViewModal;
    protected bool ModifyModal;
    protected bool HasModalError;
    protected string ModalErrorMessage;
    protected string ErrorMessage;
    protected bool DisplayError;

    protected void DisplayModalError(string error)
    {
        HasModalError = true;
        ModalErrorMessage = error;
    }

    protected void HideModalError()
    {
        HasModalError = false;
        ModalErrorMessage = "";
    }

    protected void DisplayErrorMessage(string error)
    {
        DisplayError = true;
        ErrorMessage = error;
    }

    protected void HideErrorMessage()
    {
        DisplayError = false;
        ErrorMessage = "";
    }

    protected void ShowModal()
    {
        DisplayModal = true;
    }

    protected void HideModal()
    {
        DisplayModal = false;
    }

    protected void HideAddModal()
    {
        HideModalError();
        HideModal();
    }

    protected void ShowEditModal()
    {
        HideModalError();
        ShowModal();
        ModifyModal = true;
    }

    protected abstract void Update();
    protected abstract void Add();

    protected void SaveChanges()
    {
        if (!EditContext.Validate())
        {
            return;
        }

        if (ModifyModal)
        {
            Update();
            
            return;
        }

        Add();
    }
}