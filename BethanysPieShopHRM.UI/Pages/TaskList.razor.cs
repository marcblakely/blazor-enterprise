using BethanysPieShopHRM.Shared;
using BethanysPieShopHRM.UI.Services;

using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.UI.Pages
{
  public partial class TaskList
  {
    [Inject] public ITaskDataService taskService { get; set; }
    [Inject] public NavigationManager navManager { get; set; }
    [Inject] public ILogger<TaskList> Logger { get; set; }

    [Parameter]
    public int Count { get; set; }

    public List<HRTask> Tasks { get; set; } = new List<HRTask>();

    protected override async Task OnInitializedAsync()
    {
      try
      {
        Tasks = (await taskService.GetAllTasks()).ToList();
      }
      catch(Exception ex)
      {
        Logger.LogDebug(ex, ex.Message);
      }

      if (Count != 0)
        Tasks = Tasks.Take(Count).ToList();
    }

    public void AddTask()
    {
      navManager.NavigateTo("taskedit");
    }
  }
}
