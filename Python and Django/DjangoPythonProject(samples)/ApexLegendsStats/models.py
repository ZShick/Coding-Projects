from django.db import models

LEGEND_CHOICES = (
    ('Bangalore', 'Bangalore'),
    ('Bloodhound', 'Bloodhound'),
    ('Caustic', 'Caustic'),
    ('Crypto', 'Crypto'),
    ('Fuse', 'Fuse'),
    ('Gibraltar', 'Gibraltar'),
    ('Horizon', 'Horizon'),
    ('Lifeline', 'Lifeline'),
    ('Loba', 'Loba'),
    ('Mirage', 'Mirage'),
    ('Octane', 'Octane'),
    ('Pathfinder', 'Pathfinder'),
    ('Rampart', 'Rampart'),
    ('Revenant', 'Revenant'),
    ('Valkyrie', 'Valkyrie'),
    ('Wattson', 'Wattson'),
    ('Wraith', 'Wraith'),
)

class Person(models.Model):
    name = models.CharField(max_length=60, default="", blank=True, null=False, verbose_name='Name', unique=True)

    objects = models.Manager()

    def __str__(self):
        return self.name

class Legend(models.Model):
    name = models.CharField(max_length=60, choices=LEGEND_CHOICES, verbose_name='Legend', unique=True)

    objects = models.Manager()

    def __str__(self):
        return self.name

class Entry(models.Model):
    person = models.ManyToManyField(Person)
    legend = models.ManyToManyField(Legend)
    gp = models.PositiveIntegerField(default=0, verbose_name='Games Played')
    kills = models.PositiveIntegerField(default=0, verbose_name='Kills')
    tpt3 = models.PositiveIntegerField(default=0, verbose_name='Times Placed Top 3')

    objects = models.Manager()
