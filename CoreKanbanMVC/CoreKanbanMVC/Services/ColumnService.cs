﻿using CoreKanbanMVC.DAL;
using CoreKanbanMVC.Models;

namespace CoreKanbanMVC.Services
{
    public class ColumnService
    {
        public static int DeleteColumn(int id)
        {
            return ColumnRepository.DeleteColumn(id);
        }

        public static int UpdateColumn(int id, string title)
        {
            return ColumnRepository.UpdateColumn(id, title);
        }

        public static int? CreateColumn(int boardId, string title)
        {
            return ColumnRepository.CreateColumn(title, boardId);
        }

        public static Column ReadColumn(int id)
        {
            var columnDB = ColumnRepository.ReadColumn(id);

            return new Column() { Id = columnDB.Id, Title = columnDB.Title, BoardId = columnDB.BoardId };
        }

        public static List<Column> ReadAllColumns()
        {
            var columnsDB = ColumnRepository.ReadAllColumns();
            var columns = new List<Column>();

            foreach (var columnDB in columnsDB)
            {
                columns.Add(new Column() { Id = columnDB.Id, Title = columnDB.Title, BoardId = columnDB.BoardId });
            }

            return columns;
        }

        public static List<Column> ReadColumnsInBoard(int boardId)
        {
            var columnsDB = ColumnRepository.ReadColumnsInBoard(boardId);
            var columns = new List<Column>();

            foreach (var columnDB in columnsDB)
            {
                columns.Add(new Column() { Id = columnDB.Id, Title = columnDB.Title, BoardId = columnDB.BoardId });
            }

            return columns;
        }
    }
}