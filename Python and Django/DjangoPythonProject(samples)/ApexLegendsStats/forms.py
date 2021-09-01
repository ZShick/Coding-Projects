import crispy_forms
from django.forms import ModelForm
from .models import Entry, Person, Legend, LEGEND_CHOICES
from crispy_forms.helper import FormHelper
from crispy_forms.layout import Submit, Layout, Row, Column



class PersonForm(ModelForm):
    class Meta:
        model = Person
        fields ="__all__"

class LegendForm(ModelForm):
    class Meta:
        model = Legend
        fields ="__all__"

class EntryForm(ModelForm):
    class Meta:
        model = Entry
        unique_together = (("person", "legend"),)
        fields = "__all__"
