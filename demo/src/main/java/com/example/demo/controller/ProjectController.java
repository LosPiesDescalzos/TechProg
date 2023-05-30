package com.example.demo.controller;


import com.example.demo.entity.*;
import com.example.demo.service.ProjectService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.MediaType;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping(path = "api")
public class ProjectController {

    private final ProjectService service;

    @Autowired
    public ProjectController(ProjectService service) {
        this.service = service;
    }

    @GetMapping (value = "getAllOwners", produces = MediaType.APPLICATION_JSON_VALUE)
    public List<Owner> getAllOwners () { return service.getOwner(); }

    @GetMapping (value = "getOwner", produces = MediaType.APPLICATION_JSON_VALUE)
    public Optional<Owner> findOwner (Long id) { return service.findOwnerById(id) ;}

    @GetMapping (value = "getAllPets", produces = MediaType.APPLICATION_JSON_VALUE)
    public List<Pet> getAllPets () { return service.getPet(); }

    @GetMapping (value = "getPet", produces = MediaType.APPLICATION_JSON_VALUE)
    public Optional<Pet> findPet (Long id) { return service.findPetById(id) ; }

    @PostMapping (value = "saveOwner")
    public Owner saveOwner (@RequestBody Owner owner) { return service.saveOwner(owner); }

    @PostMapping (value = "savePet")
    public Pet savePet (@RequestBody Pet pet) { return service.savePet(pet); }


}
