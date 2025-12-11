using System;

public static class FileExtension
{
    // Dictionary stored separately
    public static readonly Dictionary<string, string> Extensions =
        new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { ".mp4", "MPEG-4 Video File" },
            { ".mov", "Apple QuickTime Movie" },
            { ".avi", "Audio Video Interleave File" },
            { ".mkv", "Matroska Video File" },
            { ".webm", "WebM Video File" },
            { ".mp3", "MP3 Audio File" },
            { ".wav", "Waveform Audio File" },
            { ".flac", "Lossless Audio Codec File" },
            { ".jpg", "JPEG Image" },
            { ".jpeg", "JPEG Image" },
            { ".png", "Portable Network Graphics Image" },
            { ".gif", "Graphics Interchange Format File" },
            { ".bmp", "Bitmap Image File" },
            { ".zip", "ZIP Compressed Archive" },
            { ".rar", "RAR Compressed Archive" },
            { ".7z", "7-Zip Archive" },
            { ".pdf", "Portable Document Format" },
            { ".docx", "Microsoft Word Document" },
            { ".xlsx", "Microsoft Excel Spreadsheet" },
            { ".pptx", "Microsoft PowerPoint Presentation" },
            { ".txt", "Plain Text File" },
            { ".html", "HTML Webpage File" },
            { ".css", "Cascading Style Sheet" },
            { ".js", "JavaScript File" }
        };
}
