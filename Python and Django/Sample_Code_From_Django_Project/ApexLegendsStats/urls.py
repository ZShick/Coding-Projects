from django.urls import path
from . import views

urlpatterns = [
    path('', views.ApexHome, name="ApexHome"),
#creating the path to my home page and the name of the function in the views.py file which pulls up the correct html file
    path('enterName/', views.EnterName, name="enterName"),
    path('viewStats/', views.ViewStats, name="viewStats"),
    path('<id>', views.StatsDetails, name="statsDetails"),
    path('enterStats/', views.EnterStats, name="enterStats"),
    path('enterLegend/', views.EnterLegend, name="enterLegend"),
]
