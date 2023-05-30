package com.example.demo.service;

import com.example.demo.entity.*;
import com.example.demo.repository.OwnerRepository;
import com.example.demo.repository.PetRepository;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class ProjectService {

    private final PetRepository petRepository;
    private final OwnerRepository ownerRepository;

    public ProjectService(PetRepository petRepository, OwnerRepository ownerRepository) {
        this.petRepository = petRepository;
        this.ownerRepository = ownerRepository;
    }

    public Owner saveOwner(Owner owner){ return ownerRepository.saveAndFlush(owner); }

    public Pet savePet(Pet pet){ return petRepository.saveAndFlush(pet); }

    public List<Pet> getPet() {
        return petRepository.findAll();
    }

    public List<Owner> getOwner() {
        return ownerRepository.findAll();
    }

    public Optional<Owner> findOwnerById(Long id) { return ownerRepository.findById(id); };
    public Optional<Pet> findPetById(Long id) { return petRepository.findById(id); };

}
