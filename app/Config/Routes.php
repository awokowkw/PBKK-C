<?php

use CodeIgniter\Router\RouteCollection;

/** @var RouteCollection $routes */
$routes->get('/', 'Home::index');

$routes->group('mahasiswa', function ($routes) {
    $routes->get('/', 'Mahasiswa::index');
    $routes->get('create', 'Mahasiswa::create');
    $routes->post('store', 'Mahasiswa::store');
    $routes->get('edit/(:num)', 'Mahasiswa::edit/$1');
    $routes->post('update/(:num)', 'Mahasiswa::update/$1');
    $routes->post('delete/(:num)', 'Mahasiswa::delete/$1');
});