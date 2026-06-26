using System;
using System.Windows;
using CybersecurityAwarenessBot_Part2.Models;
using CybersecurityAwarenessBot_Part2.Services;

namespace CybersecurityAwarenessBot_Part2
{
    public partial class TaskWindow : Window
    {
        private TaskService taskService = new TaskService();

        public TaskWindow()
        {
            InitializeComponent();
        }

        private void LoadTasks()
        {
            TaskGrid.ItemsSource = null;
            TaskGrid.ItemsSource = taskService.GetAllTasks();
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TaskItem task = new TaskItem();

                task.Title = TitleBox.Text;
                task.Description = DescriptionBox.Text;
                task.ReminderDate = ReminderDatePicker.SelectedDate;
                task.IsCompleted = false;

                taskService.AddTask(task);

                MessageBox.Show("Task added successfully!");

                TitleBox.Clear();
                DescriptionBox.Clear();
                ReminderDatePicker.SelectedDate = null;

                LoadTasks();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CompleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (TaskGrid.SelectedItem == null)
            {
                MessageBox.Show("Please select a task.");
                return;
            }

            TaskItem task = (TaskItem)TaskGrid.SelectedItem;

            taskService.MarkCompleted(task.TaskID);

            LoadTasks();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (TaskGrid.SelectedItem == null)
            {
                MessageBox.Show("Please select a task.");
                return;
            }

            TaskItem task = (TaskItem)TaskGrid.SelectedItem;

            taskService.DeleteTask(task.TaskID);

            LoadTasks();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            LoadTasks();
        }
    }
}