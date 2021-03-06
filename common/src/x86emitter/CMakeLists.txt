# Check that people use the good file
if(NOT TOP_CMAKE_WAS_SOURCED)
    message(FATAL_ERROR "
    You did not 'cmake' the good CMakeLists.txt file. Use the one in the top dir.
    It is advice to delete all wrongly generated cmake stuff => CMakeFiles & CMakeCache.txt")
endif(NOT TOP_CMAKE_WAS_SOURCED)


set(Output x86emitter)

set(CommonFlags 
	-fno-strict-aliasing
    )

#Clang doesn't support a few common flags that GCC does.
if(NOT USE_CLANG)
	set(x86emitterFinalFlags
		${x86emitterFinalFlags}
		${CommonFlags} -fno-guess-branch-probability -fno-dse -fno-tree-dse
	)
endif(NOT USE_CLANG)

# Debug - Build
if(CMAKE_BUILD_TYPE STREQUAL Debug)
	# add defines
	set(x86emitterFinalFlags
		${x86emitterFinalFlags}
		${CommonFlags} -DPCSX2_DEBUG -DPCSX2_DEVBUILD
	)
endif(CMAKE_BUILD_TYPE STREQUAL Debug)

# Devel - Build
if(CMAKE_BUILD_TYPE STREQUAL Devel)
	# add defines
	set(x86emitterFinalFlags
		${x86emitterFinalFlags}
		${CommonFlags} -DPCSX2_DEVBUILD
	)
endif(CMAKE_BUILD_TYPE STREQUAL Devel)

# Release - Build
if(CMAKE_BUILD_TYPE STREQUAL Release)
	
	# add defines
	set(x86emitterFinalFlags
		${x86emitterFinalFlags}
		${CommonFlags}
	)
endif(CMAKE_BUILD_TYPE STREQUAL Release)

# variable with all sources of this library
set(x86emitterSources
	cpudetect.cpp
	fpu.cpp
	groups.cpp
	jmp.cpp
	legacy.cpp
	legacy_sse.cpp
	LnxCpuDetect.cpp
	movs.cpp
	PrecompiledHeader.cpp
	simd.cpp
	x86emitter.cpp)

# variable with all headers of this library
set(x86emitterHeaders
	../../include/x86emitter/implement/dwshift.h
	../../include/x86emitter/implement/group1.h
	../../include/x86emitter/implement/group2.h
	../../include/x86emitter/implement/group3.h
	../../include/x86emitter/implement/helpers.h
	../../include/x86emitter/implement/incdec.h
	../../include/x86emitter/implement/jmpcall.h
	../../include/x86emitter/implement/movs.h
	../../include/x86emitter/implement/simd_arithmetic.h
	../../include/x86emitter/implement/simd_comparisons.h
	../../include/x86emitter/implement/simd_helpers.h
	../../include/x86emitter/implement/simd_moremovs.h
	../../include/x86emitter/implement/simd_shufflepack.h
	../../include/x86emitter/implement/simd_templated_helpers
	../../include/x86emitter/implement/test.h
	../../include/x86emitter/implement/xchg.h
	../../include/x86emitter/instructions.h
	../../include/x86emitter/internal.h
	../../include/x86emitter/legacy_instructions.h
	../../include/x86emitter/legacy_internal.h
	../../include/x86emitter/legacy_types.h
	../../include/x86emitter/sse_helpers.h
	../../include/x86emitter/tools.h
	../../include/x86emitter/x86emitter.h
	../../include/x86emitter/x86types.h
	PrecompiledHeader.h)

set(x86emitterFinalSources
	${x86emitterSources}
	${x86emitterHeaders}
)

set(x86emitterFinalLibs
	${wxWidgets_LIBRARIES}
)

add_pcsx2_lib(${Output} "${x86emitterFinalSources}" "${x86emitterFinalLibs}" "${x86emitterFinalFlags}")
