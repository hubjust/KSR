% Copyright (c) 2009 Jaroslaw Koszuk
%
% $Id$

\NeedsTeXFormat{LaTeX2e}
\ProvidesClass{classrep}[2009/11/27 ICS Class Assignment Report]

\LoadClass[12pt,a4paper,authortitle]{mwart}
\usepackage[OT4]{polski}
\usepackage{url}

\makeatletter

\def\studycycle#1{\gdef\@studycycle{#1}}
\def\@studycycle{\ClassError{classrep}{No \noexpand\studycycle given}{}}
\def\coursesemester#1{\gdef\@coursesemester{#1}}
\def\@coursesemester{\ClassError{classrep}{No \noexpand\coursesemester given}{}}
\def\coursename#1{\gdef\@coursename{#1}}
\def\@coursename{\ClassError{classrep}{No \noexpand\coursename given}{}}
\def\courseyear#1{\gdef\@courseyear{#1}}
\def\@courseyear{\ClassError{classrep}{No \noexpand\courseyear given}{}}
\def\coursegroup#1{\gdef\@coursegroup{#1}}
\def\@coursegroup{\ClassError{classrep}{No \noexpand\coursegroup given}{}}
\def\courseteacher#1{\gdef\@courseteacher{#1}}
\def\@courseteacher{\ClassError{classrep}{No \noexpand\courseteacher given}{}}

\newcommand\studentinfo[3][]{#2&#3&\texttt{#1}}


\newcommand\coursesemesterfield{semestr}
\newcommand\courseteacherfield{Prowadz\k{a}cy}
\newcommand\reportfiledfield{Data oddania}
\newcommand\gradefield{Ocena}
\newcommand\svnurlfield{SVN}

\let\@svnurl\@empty
\newcommand{\svnurl}[1]{
  \DeclareRobustCommand{\@svnurl}{\svnurlfield: \url{#1}}
}
\newcommand\@typesetsvnurl{%
  \ifx\@svnurl\@empty
  \else
    \footnote{\@svnurl}
  \fi
}

\newcommand\@typesetauthors{%
    {\normalsize
      \begin{tabular}[t]{lrl}%
        \large\strut\@author
      \end{tabular}\par}%
}
\renewcommand{\and}{\\ \large\strut}

\newcommand\@typesettitle{{\LARGE \@title\@typesetsvnurl \par}}

\renewcommand{\@maketitle}{%
  \newpage
  \null
  \noindent\strut\@studycycle\hfill\coursesemesterfield\ \@coursesemester
  \hrule{\hspace{\textwidth}}\\
  {\large\noindent\textbf{\@coursename\hfill\@courseyear}}\\
  \noindent\strut\courseteacherfield: \@courseteacher \hfill\@coursegroup
  \hrule{\hspace{\textwidth}}\\
  \vskip \baselineskip
  \noindent\reportfiledfield: \underline{\hspace{3cm}}%
    \hfill\gradefield: \underline{\hspace{3cm}}\\
  \vskip 6\baselineskip
  \begin{center}%
  \let \footnote \thanks
    \large
    \if@authorfirst\else
      \@typesettitle%
    \vskip \baselineskip \fi
    \@typesetauthors
    \if@authorfirst
      \vskip \baselineskip
    \@typesettitle\fi
%    \ifx\@date\@empty\else
%    \vskip \baselineskip
%    {\normalsize\@date}\fi
  \end{center}%
  \par
  \vskip 1\baselineskip
  }

\makeatother
% vim:encoding=utf8 ft=tex sts=2 sw=2 et:
